import { defineStore } from "pinia";
import type { TourLinkType } from "@/types/TourLinkType";

export const useTopToursStore = defineStore("topTours", () => {
  const topLinks = ref<TourLinkType[]>([]);

  const addLink = (link: TourLinkType) => {
    // topLinks.value.push(link);
    if (!topLinks.value.some(item => item.slug === link.slug)) {
      topLinks.value.push(link);
    }
  };

  const removeLink = (link: TourLinkType) => {
    topLinks.value = topLinks.value.filter((l) => l.slug !== link.slug);
  };

  return { topLinks, addLink, removeLink };
});
