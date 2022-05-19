import { AgmInfoWindow } from '@agm/core';
import { Component, Input, OnInit } from '@angular/core';
import { ColdObservable } from 'rxjs/internal/testing/ColdObservable';
import { RestaurantDTO } from 'src/app/models/dtos/restaurant.dto';
import { ReviewDTO } from 'src/app/models/dtos/review.dto';
import { RestaurantInfo } from 'src/app/models/restaurant-info.model';

@Component({
  selector: 'app-contactreview',
  templateUrl: './contactreview.component.html',
  styleUrls: ['./contactreview.component.scss']
})

export class ContactreviewComponent implements OnInit {

  @Input() address!: string;
  @Input() restaurant!: RestaurantDTO;

  fives!: number;
  fourths!: number;
  threes!: number;
  twos!: number;
  ones!: number;
  count!: number;
  sum!: number;

  overall!: number;

  public mySentences:Array<ReviewDTO> = [
    {id: 1, review: "cool story Bob", rating: 4, visitorImg: "str"},
    {id: 2, review: "cool story Bob", rating: 5, visitorImg: "str"},
    {id: 3, review: "cool story Bob", rating: 2, visitorImg: "str"},
    {id: 4, review: "cool story Bob", rating: 3, visitorImg: "str"},
    {id: 5, review: "cool story Bob", rating: 4, visitorImg: "str"},
    {id: 6, review: "cool story Bob", rating: 4, visitorImg: "str"},
    {id: 7, review: "cool story Bob", rating: 4, visitorImg: "str"},
    {id: 8, review: "cool story Bob", rating: 4, visitorImg: "str"}
];

  restaurantForMap!: RestaurantDTO[];

  constructor() {
    this.address = "Shevska St, 8, Lviv, Lviv Oblast, 79000";
    this.fives = 0;
    this.fourths = 0;
    this.threes = 0;
    this.twos = 0;
    this.ones = 0;
    this.count = 0;
    this.sum = 0;
   }

  selectedVal = "Contacts";

  ngOnInit(): void {
    this.restaurantForMap = [this.restaurant];
  }

  public onValChange(val: string) {
    this.selectedVal = val;
  }

  public calculateRatingRatio() {
      for (let review of this.mySentences) {
        switch(review.id) {
          case 1:
            this.ones += 1;
            this.count += 1;
            this.sum += 1;
            break;
          case 2:
            this.twos += 1;
            this.count += 1;
            this.sum += 2;
            break;
          case 3:
            this.threes += 1;
            this.count += 1;
            this.sum += 3;
            break;
          case 4: 
            this.fourths += 1;
            this.count += 1;
            this.sum += 4;
            break;
          case 5:
            this.fives += 1;
            this.count += 1;
            this.sum += 5;
            break;
          default:
            break;

        }
        
      }
    this.overall = Math.round( this.sum/this.count );
    console.log(this.overall);
  }
}
