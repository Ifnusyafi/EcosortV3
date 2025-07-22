using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public JenisSampah jenisSampah;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ObjectGrabable>(out var objectGrabable))
        {
            if (objectGrabable != null)
            {
                if (objectGrabable.jenisSampah == jenisSampah)
                {
                    Debug.Log("✅ Sampah BENAR dimasukkan ke tong: " + jenisSampah);
                    GameManager.Instance.CollectTrash();
                    Destroy(collision.gameObject);
                }
                else
                {
                    Debug.Log("❌ Sampah SALAH! Seharusnya: " + jenisSampah + ", Kamu Memasukan ke " + objectGrabable.jenisSampah);
                    GameManager.Instance.CollectTrash();
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
