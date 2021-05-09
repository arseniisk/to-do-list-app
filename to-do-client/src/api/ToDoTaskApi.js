import axios from "axios";

export default class ToDoTaskApi {
  static async get() {
    try {
      const response = await axios.get("/to-do-tasks");
      return response.data;
    } catch (error) {
      let errorMessage =
        "An unknown error occured while getting a list of To Do tasks.";
      return {
        isError: true,
        error: errorMessage,
      };
    }
  }

  static async create(description) {
    try {
      const response = await axios.post("/to-do-tasks", {
        description: description,
      });
      return response.data;
    } catch (error) {
      let errorMessage = "An unknown error occured while saving a To Do task.";
      if (error.status === 422 && error.response && error.response.message) {
        errorMessage = error.response.message;
      }

      return {
        isError: true,
        error: errorMessage,
      };
    }
  }
}
