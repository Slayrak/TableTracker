import { AgmInfoWindow } from '@agm/core';
import { Component, ElementRef, OnInit, QueryList, ViewChildren } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CuisineDTO } from 'src/app/models/dtos/cuisine.dto';
import { RestaurantDTO } from 'src/app/models/dtos/restaurant.dto';
import { RestaurantInfo } from 'src/app/models/restaurant-info.model';
import { CuisineService } from 'src/app/services/cuisine.service';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { Options } from '@angular-slider/ngx-slider';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  public cuisines!: CuisineDTO[];
  checkedCuisines: CuisineDTO[] = [];

  public restaurants!: RestaurantDTO[];
  public actualRestaurants!: RestaurantDTO[];

  public types: {name: string, number: number}[] = [
    {name: "Restaurant", number: 0 },
    {name: "Fast Food", number: 1 },
    {name: "Cafe", number: 2 }
  ]

  cuisinecheckedarray: boolean[];
  typecheckedarray: boolean[];

  priceLowValue: number = 1;
  priceHighValue: number = 3;  
  priceOptions: Options = {
    floor: 1,
    ceil: 3,
    step: 1,
    showTicks: true,
  };

  ratingLowValue: number = 1;
  ratingHighValue: number = 5;  
  ratingOptions: Options = {
    floor: 1,
    ceil: 5,
    step: 1,
    showTicks: true,
  };

  checkedTypes: {name: string, number: number}[] = [];

  showMap: boolean = false;

  constructor(
    private restaurantService: RestaurantService,
    private cuisineService: CuisineService) {
      this.cuisinecheckedarray = [];
      this.typecheckedarray = [];
  }

  ngOnInit(): void {
    this.restaurantForm = new FormGroup({
      name: new FormControl(''),
      people: new FormControl(''),
      date: new FormControl(''),
      time: new FormControl(''),
    })

    this.restaurantService.getAllRestaurants()
      .subscribe((data: RestaurantDTO[]) => {
        this.restaurants = data;
        this.applyFilters();
      });

    this.cuisineService.getAllCuisines()
      .subscribe((data: CuisineDTO[]) => {
        this.cuisines = data.sort(this.compare);
      });
  }

  toggleMap() {
    this.showMap = !this.showMap;
  }

  restaurantForm!: FormGroup;

  applyFilters() {
    this.actualRestaurants = this.restaurants;

    if (this.checkedCuisines.length > 0) {
      this.actualRestaurants = this.actualRestaurants
        .filter(x => this.checkedCuisines
          .filter(y => x.cuisines
            .some(z => z.id === y.id)).length > 0);
    }
    
    if (this.checkedTypes.length > 0) {
      this.actualRestaurants = this.actualRestaurants
        .filter(x => this.checkedTypes
          .filter(y => x.type === y.number).length > 0);
    }

    this.actualRestaurants = this.actualRestaurants.filter(x =>
      x.priceRange >= this.priceLowValue && x.priceRange <= this.priceHighValue &&
      x.rating >= this.ratingLowValue && x.rating <= this.ratingHighValue);
  }

  resetFilters() {
    this.actualRestaurants = this.restaurants;
    this.checkedCuisines = [];
    this.checkedTypes = [];
    this.priceLowValue = this.priceOptions.floor as number;
    this.priceHighValue = this.priceOptions.ceil as number;
    this.ratingLowValue = this.ratingOptions.floor as number;
    this.ratingHighValue = this.ratingOptions.ceil as number;

    this.cuisinecheckedarray = [];
    this.typecheckedarray = [];
  }

  cuisineFilterChange(id: number) {
    if (this.checkedCuisines.some(x => x.id === id)) {
      this.checkedCuisines = this.checkedCuisines.filter(x => x.id !== id);
    } else {
      this.checkedCuisines.push(this.cuisines.filter(x => x.id === id)[0]);
    }
  }

  typeFilterChange(number: number) {
    if (this.checkedTypes.some(x => x.number === number)) {
      this.checkedTypes = this.checkedTypes.filter(x => x.number !== number);
    } else {
      this.checkedTypes.push(this.types.filter(x => x.number === number)[0]);
    }
  }

  compare(a: CuisineDTO, b: CuisineDTO): number {
    if (a.cuisine < b.cuisine) {
      return -1;
    }

    if (a.cuisine > b.cuisine) {
      return 1;
    }

    return 0;
  }
}
