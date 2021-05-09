<template>
  <div class="columns">
    <div class="column"></div>
    <div class="column is-8">
      <div class="card has-background-white-ter">
        <div class="card-content">
          <div class="is-size-2">To do:</div>
          <div class="tasks">
            <div class="task p-3" v-for="task in tasks" :key="task.id">
              <div class="is-size-5">
                {{ task.description }}
              </div>
              <div class="has-text-grey is-size-6">
                Created at: {{ task.createdAt | formatTimestamp }}
              </div>
            </div>
          </div>
          <hr class="has-background-grey-lighter" />
          <div class="columns">
            <div
              class="column is-2 is-size-5 has-text-right has-text-weight-bold"
            >
              Task
            </div>
            <div class="column">
              <b-field
                :type="!isInputValid ? 'is-danger' : ''"
                :message="
                  !isInputValid ? 'Please specify task description' : ''
                "
              >
                <b-input
                  v-model.trim="newTask"
                  placeholder="What do you need to do?"
                  @input="isInputValid = newTask !== ''"
                ></b-input>
              </b-field>
            </div>
          </div>
          <div class="columns">
            <div class="column has-text-right">
              <b-button type="is-info" @click="saveTask">Save Item</b-button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="column"></div>
  </div>
</template>

<script>
import ToDoTaskApi from "@/api/ToDoTaskApi";

export default {
  data: () => ({
    tasks: [],
    newTask: "",
    isInputValid: true,
  }),
  mounted() {
    this.loadTasks();
  },
  methods: {
    async saveTask() {
      if (this.newTask === "") {
        this.isInputValid = false;
        return;
      }

      const result = await ToDoTaskApi.create(this.newTask);
      if (result.isError) {
        this.showError(result.error);
        return;
      }

      this.newTask = "";
      this.tasks.push(result);
    },
    async loadTasks() {
      const tasks = await ToDoTaskApi.get();

      if (tasks.isError) {
        this.showError(tasks.error);
        this.tasks = [];
      } else {
        this.tasks = tasks;
      }
    },
    showError(errorText) {
      this.$buefy.snackbar.open({
        message: errorText,
        type: "is-danger",
        position: "is-top",
      });
    },
  },
};
</script>

<style scoped>
.tasks {
  border-radius: 6px;
  background-color: white;
}
.task:not(:last-child) {
  border-bottom: 1px solid #ededed;
}
.task > div:first-child {
  word-break: break-all;
}
</style>
