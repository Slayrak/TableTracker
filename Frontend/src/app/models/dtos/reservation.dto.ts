import { TableDTO } from "./table.dto";
import { UserDTO } from "./user.dto";

export interface ReservationDTO {
    id: number,
    date: Date,
    table: TableDTO,
    visitors: UserDTO
}
