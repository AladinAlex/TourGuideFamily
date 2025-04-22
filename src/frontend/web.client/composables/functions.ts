export function addWordDay(value: number | undefined): string {
  if(value == undefined)
    return ''
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
    return value.toLocaleString('ru-RU') + " ₽"
}

export function sendRequest(): void  {

}

export function getTourRoute(slug: string): string {
    return '/tours/' + slug;
}

export const getDuration = (durationHourMin: number | undefined, durationHourMax: number | undefined, dayCount: number | undefined) => {
  if(durationHourMin && durationHourMax)
    return durationHourMin + '-' + durationHourMax + ' ч.'
  else if(durationHourMin)
    return durationHourMin + ' ч.'
  else if(durationHourMax)
    return durationHourMax + ' ч.'
  else
    return dayCount + ' дн.'
}