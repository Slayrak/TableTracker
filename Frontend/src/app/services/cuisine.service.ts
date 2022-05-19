import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CuisineDTO } from '../models/dtos/cuisine.dto';

@Injectable({
  providedIn: 'root'
})
export class CuisineService {

  constructor(private http: HttpClient) { }

  getAllCuisines() {
    return this.http.get<CuisineDTO[]>('https://localhost:5001/api/cuisines');
  }
}
