import { Component, Input, OnInit } from '@angular/core';
import { RestaurantInfo } from 'src/app/models/restaurant-info.model';

@Component({
  selector: 'app-restaurant-map-card',
  templateUrl: './restaurant-map-card.component.html',
  styleUrls: ['./restaurant-map-card.component.scss']
})
export class RestaurantMapCardComponent implements OnInit {

  @Input() restaurant!: RestaurantInfo;

  constructor() { }

  ngOnInit(): void {
  }

  discover(): void {
    console.log(this.restaurant);
  }
}
