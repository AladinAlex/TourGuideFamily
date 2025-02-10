<script setup lang="ts">
import GuideCard from "~/components/GuideCard.vue";
import type { GuideType } from "~/types/GuideType";

let guides = ref<GuideType[]>([
  {
    firstname: "Александр",
    surname: "Аладинский",
    description: "Основатель, инструктор-проводник, гид",
    text: "Это он ответит вам, когда позвоните. Рулил автомобильным бизнесом, пока однажды на вершине Эльбруса не понял, что дело жизни выглядит совсем иначе. С тех пор прошёл вершины Кавказа, вулканы Камчатки, тысячники, перебрался на Марс, исследовал его и вернулся на Землю.",
    image: "@/assets/images/AlexandrGuide.jpg",
  },
  {
    firstname: "Марина",
    surname: "Аладинская",
    description: "Основатель, инструктор-проводник, гид",
    text: "Это он ответит вам, когда позвоните. Рулил автомобильным бизнесом, пока однажды на вершине Эльбруса не понял, что дело жизни выглядит совсем иначе. С тех пор прошёл вершины Кавказа, вулканы Камчатки, тысячники, перебрался на Марс, исследовал его и вернулся на Землю.",
    image: "@/assets/images/unknownGuide.jpg",
  },
]);
</script>

<template>
  <section class="about-us section">
    <div class="main-container max-width">
      <div class="about-us__header">
        <div class="about-us__header-lines">
          <img
            class="about-us__header-image"
            src="@/assets/images/lingonberry.png"
            alt=""
          />
        </div>
        <span class="title"
          >Сайт гидов и экскурсоводов Александра и Марины Аладинских</span
        >
      </div>
      <div class="about-us__cards">
        <GuideCard
          v-for="(guide, index) in guides"
          :key="index"
          :firstname="guide.firstname"
          :surname="guide.surname"
          :description="guide.description"
          :text="guide.text"
          :image="guide.image"
        />
      </div>
      <div class="about-us__why-we">
        <div class="about-us__why-we__title">
          <span class="title">Почему стоит выбрать нас?</span>
        </div>
        <div class="about-us__why-we__text">
          <p>
            Мы - истинные дети Камчатки! В нашей команде только местные жители,
            глубоко преданные родному краю и его уникальной природе. Каждый из
            наших гидов:
          </p >

          <ul>
            <li>Родились и выросли на Камчатке</li>
            <li>Прошли строгую государственную аттестацию</li>
            <li>Обладают глубокими знаниями истории и особенностей региона</li>
            <li>Готовы поделиться увлекательными фактами и историями</li>
          </ul>

          <p>
            Индивидуальный подход к каждому гостю - наша визитная карточка. Мы
            создаем незабываемые путешествия, учитывая интересы и пожелания
            каждого клиента. Присоединяйтесь к нам, и мы подарим вам настоящее
            погружение в мир камчатской природы! С нами ваши экскурсии
            превратятся в захватывающее путешествие с элементами личного
            открытия. Душевность, профессионализм и страсть к родному краю - вот
            что делает наши туры особенными!" Этот текст подчеркивает уникальные
            преимущества вашей компании через акцент на местных гидах, глубоких
            знаниях и персональном подходе.
          </p>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
@use "./assets/css/aboutUs.scss" as *;
</style>
