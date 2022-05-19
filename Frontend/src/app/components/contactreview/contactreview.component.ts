import { AgmInfoWindow } from '@agm/core';
import { Component, Input, OnInit } from '@angular/core';
import { ColdObservable } from 'rxjs/internal/testing/ColdObservable';
import { RestaurantDTO } from 'src/app/models/dtos/restaurant.dto';
import { RestaurantInfo } from 'src/app/models/restaurant-info.model';

@Component({
  selector: 'app-contactreview',
  templateUrl: './contactreview.component.html',
  styleUrls: ['./contactreview.component.scss']
})

export class ContactreviewComponent implements OnInit {

  @Input() restaurant!: RestaurantDTO;

  restaurantForMap!: RestaurantDTO[];

  constructor() {
   }

  selectedVal = "Contacts";

  ngOnInit(): void {
    this.restaurantForMap = [this.restaurant];
  }

  public onValChange(val: string) {
    this.selectedVal = val;
  }
}
