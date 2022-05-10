import { Component, Input, OnInit } from '@angular/core';
import { RestaurantInfo } from 'src/app/models/restaurant-info.model';

@Component({
  selector: 'app-restaurant-card',
  templateUrl: './restaurant-card.component.html',
  styleUrls: ['./restaurant-card.component.scss']
})
export class RestaurantCardComponent implements OnInit {

  @Input() restaurant!: RestaurantInfo;

  constructor() { }

  ngOnInit(): void {
  }

  discover(): void {
    console.log(this.restaurant);
  }

}
