import { Component, OnInit } from '@angular/core';
import { Task, TaskService } from './services/task.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  tasks: Task[] = [];
  newTaskTitle: string = '';

  constructor(private taskService: TaskService) {}

  ngOnInit() {
    this.loadTasks();
  }

  loadTasks() {
    this.taskService.getTasks().subscribe(tasks => {
      this.tasks = tasks;
    });
  }

  addTask() {
    if (!this.newTaskTitle.trim()) return;

    this.taskService.addTask(this.newTaskTitle.trim()).subscribe(task => {
      this.tasks.push(task);
      this.newTaskTitle = '';
    });
  }

  markCompleted(task: Task) {
    if (task.isCompleted) return; // ya está completada

    this.taskService.markCompleted(task.id).subscribe(() => {
      task.isCompleted = true;
    });
  }

  deleteTask(task: Task) {
    this.taskService.deleteTask(task.id).subscribe(() => {
      this.tasks = this.tasks.filter(t => t.id !== task.id);
    });
  }
}

