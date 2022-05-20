import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmailDTO } from '../models/dtos/email.dto';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private http: HttpClient) { }

  public sendEmail = (email: EmailDTO) => {
    return this.http.post('https://localhost:5001/api/notifications/faq-email', { body: email });
  }
}
