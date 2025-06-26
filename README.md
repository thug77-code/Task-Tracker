# Task Tracker CLI

A simple, command-line interface (CLI) application for managing daily tasks, built with .NET. This project is based on the [Task Tracker project from roadmap.sh](https://roadmap.sh/projects/task-tracker).

## Core Concepts

This project was developed with a strong emphasis on applying the **SOLID principles** of object-oriented design and implementing **Dependency Injection**.

For those who are beginning their programming journey, I highly recommend paying close attention to these topics. Understanding and applying them will greatly improve the quality, maintainability, and scalability of your code.

## How to Run

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/thug77-code/Task-Tracker.git
    ```
2.  **Navigate to the project directory:**
    ```bash
    cd "Task Tracker"
    ```
3.  **Run the application:**
    You can either run the project using the .NET CLI or through an IDE like Visual Studio.

    *   **Using the .NET CLI:**
        ```bash
        dotnet run
        ```
    *   **Using Visual Studio:**
        1.  Open the `Task Tracker.sln` file.
        2.  Press `F5` or click the "Start" button to build and run the project.

## How to Use

Once the application is running, you will see a menu with the following options:

```
Task Tracker CLI
1. Add Task
2. Update Task
3. Delete Task
4. List Tasks
5. Mark Task as Completed
6. Exit
Choose an option:
```

Here’s what each option does:

*   **1. Add Task:** Prompts you to enter a description for a new task. The task is then created with a "Pending" status.
*   **2. Update Task:** Asks for the ID of the task you want to modify, then prompts for a new description and status.
*   **3. Delete Task:** Asks for the ID of the task you wish to remove.
*   **4. List Tasks:** Displays a list of all current tasks, including their ID, description, and status.
*   **5. Mark Task as Completed:** Asks for the ID of a task and changes its status to "Completed".
*   **6. Exit:** Closes the application.

All tasks are saved to a `tasks.json` file in the project's root directory.