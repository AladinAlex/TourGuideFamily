<script setup lang="ts">
import GuideCard from "~/components/GuideCard.vue";
import SeparateLine from "~/components/SeparateLine.vue";
import type { GuideType } from "~/types/GuideType";

const props = defineProps({
  guides: {
    type: Array as PropType<GuideType[]>,
    default: () => [],
    required: true,
  }
});

let reasons = ref<{title: string, text: string}[]>([
{
  title: 'Аборигены Камчатки',
  text: 'Мы родились на Камчатке, прожили здесь всю жизнь и искренне любим свой край. Много путешествовали по полуострову и готовы показать Вам жемчужины Камчатки. Нам есть, что Вам показать!'
},
{
  title: 'Всезнайки',
  text: 'Мы аттестованные гиды-экскурсоводы, проводим экскурсии по Камчатке. Постоянно расширяем свои знания на курсах по туризму, конференциях, лекциях. Нам есть, что Вам рассказать!'
},
{
  title: 'Экономия',
  text: 'Вы напрямую без посредников обращаетесь к нам и экономите на комиссии туроператору.'
},
{
  title: 'Столько не живут, сколько мы тут работаем!',
  text: 'Мы давно работаем в сфере туризма, наш опыт и профессионализм позволяет нам работать с людьми разного возраста и физической подготовки.'
},
{
  title: 'Аккуратисты',
  text: 'Мы следим за чистотой и комфортом автомобилей, перед каждой экскурсией проводим уборку в машинах, сами опрятны и аккуратны.'
},
{
  title: 'Удобно!',
  text: 'Мы можем с Вами работать как Вам удобно - по договору или без. Оплата может производиться наличными или переводом по карте.'
},
{
  title: 'Можем и просто поговорить!',
  text: 'Вы можете обратиться к нам за консультацией, советом в организации отдыха по Камчатке. Поможем, чем можем!'
}
])

let title = 'Сайт гидов-экскурсоводов Александра и Марины Аладинских'

</script>

<template>
  <section class="about-us section">
    <div class="main-container max-width">
      <div class="about-us__header">
        <SeparateLine />
        <span class="title">{{ title }}</span>
      </div>
      <div class="about-us__cards">
        <GuideCard
          v-for="(guide, index) in guides"
          :key="index"
          :firstname="guide.firstname"
          :surname="guide.surname"
          :description="guide.description"
          :image="guide.image"
        />
      </div>
      <div class="about-us__why-we">
        <div class="about-us__why-we__title">
          <span class="title">Дорогие друзья!</span>
        </div>
        <div class="about-us__why-we__text">
          <p class="about-us-text">
            Рады приветствовать Вас на нашем сайте!
            Назовем 7 причин, почему Вам стоит обратиться за экскурсией к нам.
          </p>

          <ul>
            <li
            v-for="(reason, index) in reasons" :key="index">
              <div><span class="demibold">{{ reason.title }}</span></div>
              <div><span>{{ reason.text }}</span></div>
            </li>
          </ul>

          <p class="about-us-text">
            Индивидуальный подход к каждому гостю - наша визитная карточка.
            Мы создаем незабываемые путешествия, учитывая ваши интересы и пожелания.
            Мы подарим вам настоящее погружение в мир камчатской природы!
            Душевность, профессионализм и страсть к родному краю - вот что делает наши туры особенными!
          </p>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
@use "./assets/css/aboutUs.scss" as *;
</style>
