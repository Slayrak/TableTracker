import { RestaurantInfo } from "./restaurant-info.model";

export interface Manager {
    id: number,
    fullName: string,
    email: string,
    dateOfBirth: Date,
    location: string,
    restaurants: RestaurantInfo[],
    avatar: string;
}
