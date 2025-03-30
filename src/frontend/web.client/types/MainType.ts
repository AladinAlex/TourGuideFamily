import type { GuideType } from "./GuideType";
import type { CardTourType } from "./CardTourType";
import type { PromoType } from "./PromoType";

export type MainType = {
    guides: GuideType[],
    tours: CardTourType[],
    promos: PromoType[]
}