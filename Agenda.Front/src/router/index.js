import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: () => import('../views/Home.vue')
  },
  {
    path: '/novocliente',
    name: 'NovoCliente',
    component: () => import('../views/NovoCliente.vue')
  },
  {
    path: '/editarcliente/:id',
    name: 'EditarCliente',
    component: () => import('../views/EditarCliente.vue')
  },
  {
    path: '/cliente/:id',
    name: 'Cliente',
    component: () => import('../views/Cliente.vue')
  },
  {
    path: '/novaencomenda/:id',
    name: 'NovaEncomenda',
    component: () => import('../views/NovaEncomenda.vue')
  },
  {
    path: '/encomendas',
    name: 'Encomenda',
    component: () => import('../views/Encomendas.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
