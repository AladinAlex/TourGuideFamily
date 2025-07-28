import type { GuideType } from "./GuideType";
import type { CardTourType } from "./CardTourType";
import type { PromoType } from "./PromoType";
import type { ReviewType } from "./ReviewType";

export type MainType = {
    guides: GuideType[],
    tours: CardTourType[],
    promos: PromoType[],
    reviews: ReviewType[]
}