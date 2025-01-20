import type { Snippet } from "svelte";

export enum ModalType {
  CloseModal,
  Normal
}

let modal: {
  modalContent: Snippet | null;
  modalType: ModalType;
} = $state({
  modalContent: null,
  modalType: ModalType.Normal,
  data: 0 
});

export function openModal(newContent: Snippet, type?: ModalType) {
  modal.modalContent = newContent;
  modal.modalType = type ?? ModalType.Normal;
}

export function getModal() {
  return modal.modalContent;
}

export function closeModal() {
  modal.modalContent = null;
  modal.modalType = ModalType.Normal
}

export function getModalType() {
  return modal.modalType;
}

