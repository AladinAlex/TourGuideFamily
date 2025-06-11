import { defineEventHandler, readBody } from 'h3';
import { useRuntimeConfig } from '#imports';
import { $fetch } from 'ofetch';

export default defineEventHandler(async (event) => {
  const body = await readBody(event);
  const config = useRuntimeConfig();

  const response = await $fetch('https://www.google.com/recaptcha/api/siteverify', {
    method: 'POST',
    params: {
      secret: config.secretKey,
      response: body.token
    }
  });

  return response;
});
