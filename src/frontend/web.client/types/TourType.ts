import type { PromoType } from "./PromoType"
import type { TourProgramType } from "./TourProgramType"

export type TourType = {
    id: number,
    name: string,
    description: string,
    image: string,
    price: number,
    program: TourProgramType[],
    promos: PromoType[],
    included: String[],
    excluded: String[],
}