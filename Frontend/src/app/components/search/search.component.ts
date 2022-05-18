import { AgmInfoWindow } from '@agm/core';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CuisineDTO } from 'src/app/models/dtos/cuisine.dto';
import { RestaurantDTO } from 'src/app/models/dtos/restaurant.dto';
import { RestaurantInfo } from 'src/app/models/restaurant-info.model';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  public cuisines: Array<string> = [
    "African",
    "American",
    "Asian",
    "European",
    "Oceanic"
  ];

  public types: Array<string> = [
    "Coffee House",
    "Cafeteria",
    "Pub",
    "Cafe",
    "Fast Food",
    "Pizzeria",
    "Restaurant",
  ]

  showMap: boolean = false;

  constructor(private restaurantService: RestaurantService) {
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
      });
  }

  toggleMap(): void {
    this.showMap = !this.showMap;
  }

  restaurantForm!: FormGroup;

  public restaurants!: Array<RestaurantDTO>;

}
