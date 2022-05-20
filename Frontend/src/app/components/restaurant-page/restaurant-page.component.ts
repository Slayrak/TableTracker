import { Component, OnInit, ViewChild } from '@angular/core';
import { MatCalendar } from '@angular/material/datepicker';
import { ActivatedRoute } from '@angular/router';
import { RestaurantDTO } from 'src/app/models/dtos/restaurant.dto';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-restaurant-page',
  templateUrl: './restaurant-page.component.html',
  styleUrls: ['./restaurant-page.component.scss']
})
export class RestaurantPageComponent implements OnInit {

  image!: string;
  public isManagedRestaurant: boolean = false;

  public peopleNumber: number;
  public selectedDate: Date;

  public restaurant!: RestaurantDTO;

  constructor(
    private route: ActivatedRoute,
    private restaurantService: RestaurantService) {

    this.peopleNumber = 0;
    this.selectedDate = new Date('0001-01-01');
  }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const idFromRoute = Number(routeParams.get('id'));
    this.restaurantService.getRestaurant(idFromRoute)
      .subscribe((data: RestaurantDTO) => {
        this.restaurant = data;
        this.image = `https://localhost:5001/images/${this.restaurant.mainImage.name}`;
      });
  }

}
