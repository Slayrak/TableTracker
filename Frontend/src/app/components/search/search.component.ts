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

  latitude!: number;
  longitude!: number;

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
  
  infoWindowOpened: AgmInfoWindow|null
  previous_info_window: AgmInfoWindow|null

  constructor(private restaurantService: RestaurantService) {
    this.infoWindowOpened = null;
    this.previous_info_window = null;
    this.restaurantsForMap = [];
  }

  public restaurantsForMap!: Array<{restaurant: RestaurantDTO, latitude: number, longitude: number}>;

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

  public giveLatLong(address: string) {

    for (let restaurant of this.restaurants) {
      this.returnLatLong(restaurant.address, (latitude: number, longitude: number) => {
        this.restaurantsForMap.push({
          restaurant,
          latitude,
          longitude,
        });
      });
    }

    let geocoder = new google.maps.Geocoder();
  
    geocoder.geocode({ 'address': address }, (results, status) => {
      this.latitude = results[0].geometry.location.lat();
      this.longitude = results[0].geometry.location.lng();
      console.log("lat: " + this.latitude + ", long: " + this.longitude);
    });
  }

  public returnLatLong(address: string, callback: Function): void {
    let geocoder = new google.maps.Geocoder();

    let latitude: number = 0;
    let longitude: number = 0;
  
    geocoder.geocode({ 'address': address }, (results, status) => {
      latitude = results[0].geometry.location.lat();
      longitude = results[0].geometry.location.lng();
      console.log("lat: " + this.latitude + ", long: " + this.longitude);
      callback(latitude, longitude);
    });
  }

  icon = {
    url: './assets/location-sign-svgrepo-com.svg',
    scaledSize: {
      width: 40,
      height: 60
    }
  }

  close_window(){
    if (this.previous_info_window != null ) {
      this.previous_info_window.close()
    }
  }

  select_marker(infoWindow){
    if (this.previous_info_window == null)
      this.previous_info_window = infoWindow;
    else {
      this.infoWindowOpened = infoWindow
      this.previous_info_window.close()
    }

    this.previous_info_window = infoWindow
  }
}
