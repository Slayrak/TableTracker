import { Component, OnInit } from '@angular/core';
import { ColdObservable } from 'rxjs/internal/testing/ColdObservable';
import { RestaurantInfo } from 'src/app/models/restaurant-info.model';

@Component({
  selector: 'app-contactreview',
  templateUrl: './contactreview.component.html',
  styleUrls: ['./contactreview.component.scss']
})
export class ContactreviewComponent implements OnInit {

  constructor() { }

  selectedVal = "Contacts";

  latitude = 0;
  longitude = 0;

  ngOnInit(): void {
    
  }

  public onValChange(val: string) {
    this.selectedVal = val;
  }

  public giveLatLong() {
    let address = "Shevska St, 8, Lviv, Lviv Oblast, 79000";

    let geocoder = new google.maps.Geocoder();

    let result = "";
  
    geocoder.geocode({ 'address': address }, (results, status) => {
      this.latitude = results[0].geometry.location.lat();
      this.longitude = results[0].geometry.location.lng();
      console.log("lat: " + this.latitude + ", long: " + this.longitude);
      });
  }

  icon = {
    url: './assets/location-sign-svgrepo-com.svg',
    scaledSize: {
      width: 40,
      height: 60
    }
    
  }

  public restaurant: RestaurantInfo =
  {
    id: 1,
    name: "WA Restaurant",
    tags: ["Japanese", "Seafood", "Asian"],
    priceRating: 3,
    rating: 5,
    image: "https://crestins.com/wp-content/uploads/2021/04/nick-karvounis-Ciqxn7FE4vE-unsplash.jpg",
    description: "WA restaurant started a smart fusion cousine. It's a new approach to gastronomy, presentation and food combination. WA took base of Asian cuisine with a taste of modern European traditions. We promote a harmony of quality, taste and aesthetic. We offer to taste bowls...",
  };


  openedWindow : number = 0; // alternative: array of numbers

openWindow(id) {
    this.openedWindow = id; // alternative: push to array of numbers
}

isInfoWindowOpen(id) {
    return this.openedWindow == id; // alternative: check if id is in array
}

  // address = "1045 mission street san francisco";

  // geocoder = new google.maps.Geocoder();

  // result = "";
  
  // geocoder.geocode({ 'address': address }, (results, status) => {
  //   var latitude = results[0].geometry.location.lat();
  //   var longitude = results[0].geometry.location.lng();
  //   console.log("lat: " + latitude + ", long: " + longitude);
  //   });

}
