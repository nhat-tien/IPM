import type { Snippet } from "svelte";

let modal: Snippet | null = $state(null);

export function openModal(newContent: Snippet) {
  modal = newContent;
}

export function getModal() {
  return modal;
}

export function closeModal() {
  modal = null;
}

