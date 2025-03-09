export function addWordDay(value: number): string {
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