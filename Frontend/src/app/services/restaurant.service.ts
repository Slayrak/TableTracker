import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { RestaurantDTO } from '../models/dtos/restaurant.dto';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  constructor(private http: HttpClient) { }

  getRestaurant(id: number) {
    return this.http.get<RestaurantDTO>(`https://localhost:5001/api/restaurants/${id}`);
  }

  getAllRestaurants() {
    return this.http.get<RestaurantDTO[]>("https://localhost:5001/api/restaurants");
  }
}
