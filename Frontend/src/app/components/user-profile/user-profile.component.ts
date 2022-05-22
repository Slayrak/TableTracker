import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RestaurantDTO } from 'src/app/models/dtos/restaurant.dto';
import { VisitorDTO } from 'src/app/models/dtos/visitor.dto';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {
  
  public restaurants!: RestaurantDTO[];

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
      .subscribe((data: VisitorDTO) => this.user = data);
  }

  discover(id: number): void {
    console.log(this.user.reservations.filter(x => x.id === id)[0]);
  }

}
