<script setup lang="ts">
import TourProgram from "~/components/TourProgram.vue";
import PresentationTour from "~/components/PresentationTour.vue";
import Promo from "~/components/Promo.vue";
import FeedbackForm from "~/components/FeedbackForm.vue";
import type { TourType } from "~/types/TourType";
import FeedbackModal from "@/components/Modals/FeedbackModal.vue";
import { useModalStore } from "@/stores/modal";


definePageMeta({
  title: "Страница тура",
  layout: "default",
});

const tour: TourType = {
  id: 1,
  name: "Восхождение на вулкан Горелый",
  description:
    "Погрузитесь в горные массивы Камчатки! Заберитесь на один из самых популярных вулканов Камчатки.",
  price: 50000,
  image:
    // "@/assets/images/tourImage.jpg", // URL изображения
    "https://admin.landintheocean.ru/img/Tour/voskhozhdenienavulkangorelyy/2f986d6a-302a-4378-879b-48c1788f1fa0_gorelyylogo.jpg",
  program: [
    {
      day: 1,
      name: "Восхождение на вулкан Горелый",
      description:
        "Вулкан Горелый расположен всего в 75 км от Петропавловска-Камчатского и представляет собой мощную гору, сохраняющую свою вулканическую деятельность. Находится в заповеднике Камчатского края и включен в список объектов Всемирного наследия Юнеско. Маршрут на вулкан Горелый предлагает впечатляющие пейзажи, начиная от посещения Вилючинского перевала откуда открывается вид на вулканы Вилючинский, Мутновский, Горелый, Опала. На подъезде к вулкану видно огромная кальдера от мощного извержения в далекие годы, что напоминает по сей день лунный ландшафт. Само восхождение проходит, как и по сухой тропе, так и по снегу, в зависимости от месяца восхождения. Покорив вершину первым делом у вас захватит дух от увиденного! Перед вами необъятных размеров кратер вулкана, который наполнен озером лазурного цвета, а стоит пройтись по кромке кратера чуть дальше, то вашему вниманию предстанет кратер с активными фумаролами.",
      image:
        "https://admin.landintheocean.ru/img/Tour/voskhozhdenienavulkangorelyy/2f986d6a-302a-4378-879b-48c1788f1fa0_gorelyylogo.jpg",
    },
    {
      day: 2,
      name: "",
      description: "Поход к водопаду «Семиголосье».",
      image: "",
    },
    {
      day: 3,
      name: "",
      description: "Экскурсия в пещеру «Катунь».",
      image: "",
    },
  ],
  promos: [
    {
      image: "",
      title: "Сложность",
      description: "Маршрут относится к средней сложности",
    },
    {
      image: "",
      title: "Возрастное ограничение",
      description: "Приемлемый возвраст от 8 лет",
    },
    {
      image: "",
      title: "Протяженность",
      description: "Протяженность маршрута пешком составляет 8 км",
    },
  ],
  included: [
    "Все трансферы по программе",
    "Питание на активной части маршрута",
    "Сопровождение профессиональных гидов",
    "Групповая аптечка",
    "Треккинговые палки",
  ],
  excluded: [
    "Перелёт из вашего города в Петропавловск-Камчатский и обратно",
    "Питание в городе – средний чек в кафе от 500 до 1500 руб.",
    "Аренда личного снаряжения при необходимости (спальник, трекинговые палки)",
    "Проживание в хостеле или гостинице до и после маршрута",
  ],
};

var buttonText = "Оставить заявку";

const modal = useModalStore();
const handleClick = () => {
  modal.open({
    component: FeedbackModal,
    componentProps: {},
  });
};
</script>

<template>
  <div class="tour-page">
    <!-- Фоновое изображение -->
    <div
      class="background-image"
      :style="{ backgroundImage: `url(&quot;${tour.image}&quot;)` }"
    >
      <div class="content-overlay">
        <h1 class="tour-title">{{ tour.name }}</h1>

        <p class="tour-description">{{ tour.description }}</p>

        <div class="tour-price">
          <img
            src="@/assets/images/ruble6.png"
            class="tour-price__image"
            alt="Рубль"
          />
          <span class="tour-price__text">{{ formatPrice(tour.price) }}</span>
        </div>

        <div class="tour-duration">
          <img
            src="@/assets/images/time1.png"
            class="tour-duration__image"
            alt="Рубль"
          />
          <span class="tour-duration__text">
            {{
              tour.program.length + " " + addWordDay(tour.program.length)
            }}</span
          >
        </div>

        <button class="tour-btn" @click="handleClick">{{ buttonText }}</button>
      </div>
    </div>
  </div>
  <TourProgram :program="tour.program" />
  <PresentationTour
    :price="tour.price"
    :included="tour.included"
    :excluded="tour.excluded"
  />
  <Promo :promos="tour.promos" />
  <FeedbackForm :tourId="tour.id" />
</template>

<style scoped lang="scss">
@use "./assets/css/tour.scss" as *;
</style>
