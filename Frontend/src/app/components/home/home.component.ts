import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RestaurantDTO } from 'src/app/models/dtos/restaurant.dto';
import { RestaurantInfo } from 'src/app/models/restaurant-info.model';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public myFormGroup!: FormGroup;

  public restaurants!: Array<RestaurantDTO>;

  constructor(private restaurantService: RestaurantService) { }

  ngOnInit(): void {
    this.myFormGroup = new FormGroup({
      people: new FormControl('', Validators.required),
      date: new FormControl('', Validators.required),
      time: new FormControl('', Validators.required),
      restaurant: new FormControl('', Validators.required),
    })

    this.restaurantService.getAllRestaurants()
      .subscribe((data: RestaurantDTO[]) => this.restaurants = data);
  }

  onsubmit(): void {
    console.log(this.myFormGroup.value);
  }

}
