import type { PromoType } from "./PromoType"
import type { DayType } from "./DayType"

export type TourType = {
    image: string,
    name: string,
    description: string,
    minParticipants: number,
    maxParticipants: number,
    price: number,
    durationHour: number | undefined,
    days: DayType[],
    promos: PromoType[],
    included: string[],
    excluded: string[],
}