using Utilites.Pooling;

namespace NabilahKishou.TazkanTest
{
    public class ColorPooler : CustomPoolManager<ColorDrop>
    {
        protected override ColorDrop CreateObject()
        {
            var go = Instantiate(_objectPrefab, this.transform);
            go.gameObject.SetActive(false);
            return go;
        }

        protected override void OnTakeFromPool(ColorDrop obj)
        {
            obj.gameObject.SetActive(true);
        }

        protected override void OnReturnedToPool(ColorDrop obj)
        {
            obj.gameObject.SetActive(false);
        }

        protected override void OnDisposedObject(ColorDrop obj)
        {
            Destroy(obj);
        }

        public static ColorDrop GetDroplet() => Instance.GetObject();
        public static void Return(ColorDrop color) => Instance.ReturnObject(color);
    }
}