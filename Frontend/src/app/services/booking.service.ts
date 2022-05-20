import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TableDTO } from '../models/dtos/table.dto';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private http: HttpClient) { }

  getRestaurantTables(id:number) {
    this.http.get<TableDTO[]>(`https://localhost:5001/api/tables/restaurant/${id}`)
  }

}
