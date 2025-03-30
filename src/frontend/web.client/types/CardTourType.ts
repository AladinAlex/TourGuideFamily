
export type CardTourType = {
    id: number,
    image: string,
    name: string,
    minParticipants: number,
    maxParticipants: number,
    price: number,
    durationHour: number | undefined,
    dayCount: number
}