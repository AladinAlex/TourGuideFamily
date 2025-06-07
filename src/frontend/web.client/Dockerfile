# ========== Этап сборки ==========
FROM node:18-alpine AS builder

WORKDIR /app

# Копируем package.json и lock-файлы (для кэширования зависимостей)
COPY package*.json ./

# Устанавливаем зависимости (включая dev-зависимости для сборки)
RUN npm install --frozen-lockfile

# Копируем исходный код
COPY . .

# Собираем приложение (создаем .output)
RUN npm run build

# ========== Этап запуска ==========
FROM node:18-alpine AS production

WORKDIR /app

# Копируем package.json для production-зависимостей
COPY --from=builder /app/package*.json ./

# Устанавливаем ТОЛЬКО production-зависимости (без devDependencies)
RUN npm install --omit=dev

# Копируем собранное приложение из builder
COPY --from=builder /app/.output ./.output

# Указываем порт, который слушает Nuxt (по умолчанию 3000)
EXPOSE 3000

# Запускаем сервер Nitro (SSR)
CMD ["node", ".output/server/index.mjs"]

#cd C:\dev\TourGuideFamily\src\frontend\web.client
#docker build -t tour_frontend:1.0.0 -f Dockerfile .
#docker run -d --name frontend -p 5062:3000 -P tour_frontend:1.0.0