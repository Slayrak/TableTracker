import { Discount } from "../enums/discount.enum"
import { RestaurantType } from "../enums/restaurant.enum"
import { CuisineDTO } from "./cuisine.dto"
import { ImageDTO } from "./image.dto"

export interface RestaurantDTO {
    id: number,
    address: string,
    name: string,
    description: string,
    rating: number,
    priceRange: number,
    numberOfTables: number
    type: RestaurantType,
    discount: Discount,
    mainImage: ImageDTO,
    cuisines: CuisineDTO[],
}
