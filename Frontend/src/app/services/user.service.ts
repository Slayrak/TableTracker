import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ManagerDTO } from '../models/dtos/manager.dto';
import { VisitorDTO } from '../models/dtos/visitor.dto';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getVisitor(id: number) {
    return this.http.get<VisitorDTO>(`https://localhost:5001/api/visitors/${id}`);
  }

  getManager(id: number) {
    return this.http.get<ManagerDTO>(`https://localhost:5001/api/managers/${id}`);
  }
}
