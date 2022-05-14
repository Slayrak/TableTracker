import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { RestaurantInfo } from 'src/app/models/restaurant-info.model';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  public cuisines: Array<string> = [
    "African",
    "American",
    "Asian",
    "European",
    "Oceanic"
  ];

  public types: Array<string> = [
    "Coffee House",
    "Cafeteria",
    "Pub",
    "Cafe",
    "Fast Food",
    "Pizzeria",
    "Restaurant",
  ]

  constructor() { }

  ngOnInit(): void {
    this.restaurantForm = new FormGroup({
      name: new FormControl(''),
      people: new FormControl(''),
      date: new FormControl(''),
      time: new FormControl(''),
    })
  }

  restaurantForm!: FormGroup;

  public restaurants: Array<RestaurantInfo> = [
    {
      id: 1,
      name: "Baczewski Restaurant",
      tags: ["Polish", "European"],
      priceRating: 3,
      rating: 5,
      image: "https://crestins.com/wp-content/uploads/2021/04/nick-karvounis-Ciqxn7FE4vE-unsplash.jpg",
      description: "The Baczewski family has known all over Europe and the world since 1782, when they opened a factory for mass production of vodka. Now the legendary vodka has returned to Lviv...",
    },
    {
      id: 2,
      name: "Edison Pub",
      tags: ["European"],
      priceRating: 2,
      rating: 5,
      image: "data:image/jpeg;base64,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",
      description: "Best place for a good evening, good music, nice drinks or deliciuos food! Also good shots.",
    },
    {
      id: 3,
      name: "Teddy Restaurant",
      tags: ["Italian", "Pizza"],
      priceRating: 3,
      rating: 5,
      image: "https://images.unsplash.com/photo-1574521091464-a55e7763c1e5?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1000&q=80",
      description: "Great and cozy place with open kitchen. Very tasty pasta and big pizza. Delicious meals and really cute teddy bear sitting next to you.",
    },
    {
      id: 4,
      name: "Sowa",
      tags: ["European", "International"],
      priceRating: 2,
      rating: 5,
      image: "https://images.unsplash.com/photo-1574521091464-a55e7763c1e5?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1000&q=80",
      description: "One of the best places in Lviv to visit. Very tasty food complemented by the cute interior of the cafe.",
    },
    {
      id: 5,
      name: "Culinary Studio Kryva Lypa",
      tags: ["European", "Italian", "Ukrainian"],
      priceRating: 3,
      rating: 5,
      image: "https://images.unsplash.com/photo-1574521091464-a55e7763c1e5?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1000&q=80",
      description: "All in all fantastic food, great service, very friendly and helpful. Food came on time and timed with each other. Would recommend this restaurant to everyone coming to lviv...",
    }
  ];
}
