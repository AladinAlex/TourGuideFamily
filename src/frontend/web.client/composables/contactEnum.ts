import type { ContactType } from "~/types/ContactType";

export const useContactOptions = () => {
    const contactOptions: ContactType[] = [
      { id: 1, value: 'Написать в Telegram' },
      { id: 2, value: 'Написать в WhatsApp' },
      { id: 3, value: 'Позвонить' },
    ];
  
    return { contactOptions };
  };