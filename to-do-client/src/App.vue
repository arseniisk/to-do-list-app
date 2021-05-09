<template>
  <div id="app">
    <div class="container">
      <to-do-task-card></to-do-task-card>
    </div>
  </div>
</template>

<script>
import ToDoTaskCard from "@/components/ToDoTaskCard.vue";

export default {
  name: "App",
  components: {
    ToDoTaskCard,
  },
};
</script>

<style scoped>
.container {
  margin-top: 3rem;
}
</style>
