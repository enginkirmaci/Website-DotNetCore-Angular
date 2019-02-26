import { Component, Input } from "@angular/core";

@Component({
    selector: "gallery",
    templateUrl: "./gallery.component.html"
})
export class GalleryComponent {
    @Input() data: any;
    @Input() layout: number;
}