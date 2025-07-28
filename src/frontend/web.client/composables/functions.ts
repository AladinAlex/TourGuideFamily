export function addWordDay(value: number | undefined): string {
  if (value == undefined) return "";
  const lastDigit = value % 10;
  const lastTwoDigits = value % 100;
  if (lastDigit === 1 && lastTwoDigits !== 11) {
    return "день";
  } else if (
    lastDigit >= 2 &&
    lastDigit <= 4 &&
    !(lastTwoDigits >= 12 && lastTwoDigits <= 14)
  ) {
    return "дня";
  } else {
    return "дней";
  }
}

export function formatPrice(value: number): string {
  return value.toLocaleString("ru-RU") + " ₽";
}

export function sendRequest(): void {}

export function getTourRoute(slug: string): string {
  return "/tours/" + slug;
}

export const getDuration = (
  durationHourMin: number | undefined,
  durationHourMax: number | undefined,
  dayCount: number | undefined
) => {
  if (durationHourMin && durationHourMax)
    return durationHourMin + "-" + durationHourMax + " ч.";
  else if (durationHourMin) return durationHourMin + " ч.";
  else if (durationHourMax) return durationHourMax + " ч.";
  else return dayCount + " дн.";
};

export const getStarRating = (
  rating: number,
  showEmptyStars: boolean = false
) => {
  // Проверка входных данных
  if (typeof rating !== "number" || rating < 1 || rating > 5) {
    console.error("Рейтинг должен быть числом от 1 до 5");
    return showEmptyStars ? "☆☆☆☆☆" : "";
  }

  const roundedRating = Math.round(rating * 2) / 2;
  let stars = "";

  const fullStars = Math.floor(roundedRating);
  stars += "★".repeat(fullStars);

  if (roundedRating % 1 !== 0) {
    stars += "½";
  }

  if (showEmptyStars) {
    const emptyStarsCount = 5 - Math.ceil(roundedRating);
    stars += "☆".repeat(emptyStarsCount);
  }

  return stars;
};

export const formatDate = (date: Date | string) => {
    const dateObj = typeof date === 'string' 
    ? new Date(date + 'T00:00:00Z')
    : new Date(date);

  if (isNaN(dateObj.getTime())) {
    console.error('Invalid date:', date);
    return 'Некорректная дата';
  }

  return dateObj.toLocaleDateString('ru-RU', {
    day: 'numeric',
    month: 'long',
    year: 'numeric',
    timeZone: 'UTC',
  });
};
