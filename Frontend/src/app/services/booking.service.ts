import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReservationDTO } from '../models/dtos/reservation.dto';
import { TableDTO } from '../models/dtos/table.dto';
import { CommandResult } from '../models/enums/command-result';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private http: HttpClient) { }

  getRestaurantTables(id:number) {
    return this.http.get<Array<TableDTO>>(`https://localhost:5001/api/tables/restaurant/${id}`)
  }

  getReservationsForTable(id:number, date: Date) {

    return this.http.get<Array<ReservationDTO>>(`https://localhost:5001/api/tables/${id}/reservations`,{
        params: {
          date: date.toISOString()
        }
      }
    )
  }

  createReservation(reservation: ReservationDTO) {
    return this.http.post<{commandResult: CommandResult;
      errorMessage: string;
      obj: ReservationDTO;}>(`https://localhost:5001/api/reservations`, reservation)

  }

}
