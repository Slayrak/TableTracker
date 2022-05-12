import { Component, OnInit } from '@angular/core';
import { Manager } from 'src/app/models/manager.model';
import { RestaurantInfo } from 'src/app/models/restaurant-info.model';

@Component({
  selector: 'app-manager-profile',
  templateUrl: './manager-profile.component.html',
  styleUrls: ['./manager-profile.component.scss']
})
export class ManagerProfileComponent implements OnInit {
  
  public restaurants: Array<RestaurantInfo> = [
  {
    id: 1,
    name: "Baczewski Restaurant",
    tags: ["Polish", "European"],
    priceRating: 3,
    rating: 5,
    image: "https://crestins.com/wp-content/uploads/2021/04/nick-karvounis-Ciqxn7FE4vE-unsplash.jpg",
    description: "The Bachevsky family has known all over Europe and the world since 1782, when they opened a factory for mass production of vodka. Now the legendary vodka has returned to Lviv...",
  },
];

  user: Manager = {
    id: 1,
    fullName: "Marina Marinenko",
    email: "marinenko@mail.kp",
    dateOfBirth: new Date("1969-05-12"),
    location: "Lviv, Ukarine",
    restaurants: this.restaurants,
    avatar: "https://images.unsplash.com/photo-1573496359142-b8d87734a5a2?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTR8fGJvc3N8ZW58MHx8MHx8&w=1000&q=80",
  }

  constructor() { }

  ngOnInit(): void {
  }

}
