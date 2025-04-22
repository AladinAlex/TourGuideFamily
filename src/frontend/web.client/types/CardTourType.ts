
export type CardTourType = {
    image: string,
    name: string,
    minParticipants: number,
    maxParticipants: number,
    price: number,
    durationHourMin: number | undefined,
    durationHourMax: number | undefined,
    dayCount: number,
    slug: string
}