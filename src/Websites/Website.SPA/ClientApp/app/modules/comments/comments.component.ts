import { Component, Input } from "@angular/core";

@Component({
    selector: "comments",
    templateUrl: "./comments.component.html"
})
export class CommentsComponent {
    @Input() layout: number;
}