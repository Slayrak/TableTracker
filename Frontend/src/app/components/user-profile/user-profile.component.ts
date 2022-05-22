import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ReservationDTO } from 'src/app/models/dtos/reservation.dto';
import { RestaurantDTO } from 'src/app/models/dtos/restaurant.dto';
import { VisitorDTO } from 'src/app/models/dtos/visitor.dto';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {
  
  public shownRestaurants!: RestaurantDTO[];
  public shownReservations!: ReservationDTO[];

  user!: VisitorDTO;
  userId!: number;

  constructor(
    private route: ActivatedRoute,
    private userService: UserService) { }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const idFromRoute = Number(routeParams.get('id'));
    this.userId = idFromRoute;

    this.userService.getVisitor(idFromRoute)
      .subscribe((data: VisitorDTO) => {
        this.user = data;

        for (let i = 0; i < this.user.reservations.length; i++) {
          this.user.reservations[i].date = new Date(this.user.reservations[i].date)
        }

        this.shownRestaurants = this.user.favourites.slice(0, 3);
        this.shownReservations = this.user.reservations.filter(x => x.date >= new Date());
      });
  }

  getImageSource(image: string) {
    return `https://localhost:5001/images/${image}`;
  }

}
