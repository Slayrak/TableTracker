import { AgmInfoWindow } from '@agm/core';
import { Component, OnInit } from '@angular/core';
import { ColdObservable } from 'rxjs/internal/testing/ColdObservable';
import { RestaurantInfo } from 'src/app/models/restaurant-info.model';

@Component({
  selector: 'app-contactreview',
  templateUrl: './contactreview.component.html',
  styleUrls: ['./contactreview.component.scss']
})

export class ContactreviewComponent implements OnInit {

  infoWindowOpened: AgmInfoWindow|null
  previous_info_window: AgmInfoWindow|null


  constructor() {
    this.infoWindowOpened = null;
    this.previous_info_window = null;
   }

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

  close_window(){
    if (this.previous_info_window != null ) {
      this.previous_info_window.close()
      }    
    }
    
    select_marker(infoWindow){
     if (this.previous_info_window == null)
      this.previous_info_window = infoWindow;
     else{
      this.infoWindowOpened = infoWindow
      this.previous_info_window.close()
     }
     this.previous_info_window = infoWindow
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
