import type { Attachment } from "svelte/attachments"

function handleElementClickBoundary({ onInside, onOutside }: 
  {
    onInside?: () => void,
    onOutside?: () => void,
  }
): Attachment {
  return (element) => {
    function onClick(e: any) {
      if (element.contains(e.target as Node)) {
        onInside?.();
      } else {
        onOutside?.();
      }
    }
    document.body.addEventListener("click", onClick);
    return () => {
      document.body.removeEventListener("click", onClick)
    }
  }
}

export default handleElementClickBoundary;
