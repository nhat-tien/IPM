
export type EventSelectElements = Event & {
  currentTarget: EventTarget & HTMLSelectElement;
}
export type EventSubmitElements = SubmitEvent & {
  currentTarget: EventTarget & HTMLFormElement;
}
export type WindowMouseEvent = MouseEvent & {
  currentTarget: EventTarget & Window;
}

export type CustomDragEvent = DragEvent & {
    currentTarget: EventTarget & HTMLDivElement;
}

