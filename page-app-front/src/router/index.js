import { createRouter, createWebHistory } from 'vue-router'
import Studenti from '../views/Studenti.vue'
import Kursevi from '../views/Kursevi.vue'
import Prijava from '../views/Prijava.vue'
import DodajIzmjeniKurs from '../views/DodajIzmjeniKurs'
import DodajIzmjeniStudent from '../views/DodajIzmjeniStudent'
import StudentDetalji from '../views/StudentDetalji'
import KursDetalji from '../views/KursDetalji'

const routes = [
  {
    path: '/studenti',
    name: 'Studenti',
    component: Studenti
  },
  {
    path: '/kursevi',
    name: 'Kursevi',
    component: Kursevi
  },
  {
    path: '/prijava',
    name: 'Prijava',
    component: Prijava
  },
  {
    path: '/studenti/dodaj-izmjeni',
    name: 'Distudent',
    component: DodajIzmjeniStudent
  },
  {
    path: '/kursevi/dodaj-izmjeni',
    name: 'Dikurs',
    component: DodajIzmjeniKurs
  },
  {
    path: '/studenti/detalji/:id?',
    name: 'StudentDetalji',
    component: StudentDetalji
  },
  {
    path: '/kursevi/detalji/:id?',
    name: 'KursDetalji',
    component: KursDetalji
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
