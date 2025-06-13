import type { Attachment } from "svelte/attachments"

function handleElementClickBoundary({ onInside, onOutside }:
  {
    onInside?: () => void,
    onOutside?: () => void,
  }
): Attachment {
  return (element) => {
    function onClickOutside(e: Event) {
      if (!element.contains(e.target as Node)) {
        onOutside?.();
      }
    }
    function onClickInside() {
      onInside?.();
    }
    document.body.addEventListener("click", onClickOutside);
    element.addEventListener("click", onClickInside);
    return () => {
      document.body.removeEventListener("click", onClickOutside);
      element.removeEventListener("click", onClickInside);
    }
  }
}

export default handleElementClickBoundary;
