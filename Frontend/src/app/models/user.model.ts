import { Booking } from "./booking.model";
import { RestaurantInfo } from "./restaurant-info.model";

export interface User {
    id: number,
    fullName: string,
    email: string,
    dateOfBirth: Date,
    location: string,
    userBookings: Booking[],
    favourites: RestaurantInfo[],
    avatar: string;
} 
