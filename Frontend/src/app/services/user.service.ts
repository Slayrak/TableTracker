import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ImageDTO } from '../models/dtos/image.dto';
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

  updateVisitor(user: VisitorDTO) {
    return this.http.put('https://localhost:5001/api/visitors', user);
  }

  getManager(id: number) {
    return this.http.get<ManagerDTO>(`https://localhost:5001/api/managers/${id}`);
  }

  uploadAvatar(id: number, formData: FormData) {
    return this.http.post<ImageDTO>(`https://localhost:5001/api/visitors/${id}/avatar`, formData);
  }

  deleteAvatar(id: number) {
    return this.http.delete(`https://localhost:5001/api/visitors/${id}/avatar`);
  }
}
